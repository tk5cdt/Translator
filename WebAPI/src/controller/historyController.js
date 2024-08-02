import e from 'express';
import { connectDB } from '../configs/connectDB';

let getHistory = async (req, res) => {
    try{
        let {uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`SELECT WORDID, ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE FROM HISTORY WHERE UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let saveHistory = async (req, res) => {
    try{
        let {originalword, translatedword, fromlanguage, tolanguage,timesave, uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`INSERT INTO HISTORY(ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE, UID) VALUES('${originalword}', '${translatedword}', '${fromlanguage}', '${tolanguage}', '${timesave}', ${uid})`);
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

module.exports = {
    getHistory,
    saveHistory,
    deleteHistory
}