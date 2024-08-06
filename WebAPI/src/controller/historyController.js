import e from 'express';
import { connectDB, sql } from '../configs/connectDB';

let getHistory = async (req, res) => {
    try{
        let {uid} = req.query;
        let pool = await connectDB();
        let result = await pool.request().query(`SELECT WORDID, ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE, UID, ISFAVORITE FROM HISTORY WHERE UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
        console.log("error" + err);
    }
}

const  saveHistory = async (req, res) => {
    try{
        let {originalword, translatedword, fromlanguage, tolanguage,timesave, uid, isfavorite} = req.body;

        let pool = await connectDB();
        let result = await pool.request()
            .input('originalword', sql.NVarChar, originalword)
            .input('translatedword', sql.NVarChar, translatedword)
            .input('fromlanguage', sql.NVarChar, fromlanguage)
            .input('tolanguage', sql.NVarChar, tolanguage)
            .input('timesave', sql.DateTime, timesave)
            .input('isfavorite', sql.Bit, isfavorite)
            .input('uid', sql.Int, uid)
            
            .query('INSERT INTO HISTORY(ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE, ISFAVORITE, UID) VALUES(@originalword, @translatedword, @fromlanguage, @tolanguage, @timesave, @isfavorite, @uid)');
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let deleteHistory = async (req, res) => {
    try{
        let {wordid, uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`DELETE FROM HISTORY WHERE WORDID = ${wordid} AND UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let deleteAllHistory = async (req, res) => {
    try{
        let {uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`DELETE FROM HISTORY WHERE UID = ${uid}`);
        return res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}
let updateHistory = async (req, res) => {
    try {
        let { isfavorite, wordid, uid } = req.body;

        // Ghi lại giá trị đầu vào
        console.log('isfavorite:', isfavorite);
        console.log('wordid:', wordid);
        console.log('uid:', uid);

        // Chuyển đổi isfavorite thành boolean
        isfavorite = parseBoolean(isfavorite);

        // Kiểm tra giá trị sau khi chuyển đổi
        console.log('isfavorite (converted):', isfavorite);

        // if (isfavorite === null || typeof wordid !== 'number' || typeof uid !== 'number') {
        //     return res.status(400).json({ message: 'Invalid input' });
        // }

        let pool = await connectDB();

        let request = pool.request();
        request.input('isfavorite', isfavorite);
        request.input('wordid', wordid);
        request.input('uid', uid);

        let result = await request.query(`
            UPDATE HISTORY
            SET ISFAVORITE = @isfavorite
            WHERE WORDID = @wordid AND UID = @uid
        `);

        res.status(200).json(result.rowsAffected); // Trả về số lượng hàng bị ảnh hưởng
    } catch (err) {
        console.log(err);
        res.status(500).json({ message: 'Internal server error' });
    }
};

// Định nghĩa hàm parseBoolean
function parseBoolean(value) {
    if (typeof value === 'boolean') {
        return value;
    } else if (typeof value === 'string') {
        value = value.toLowerCase();
        if (value === 'true') {
            return true;
        } else if (value === 'false') {
            return false;
        }
    }
    return null; // Giá trị mặc định hoặc lỗi
}

module.exports = { updateHistory };


module.exports = {
    getHistory,
    saveHistory,
    deleteHistory,
    deleteAllHistory,
    updateHistory
}