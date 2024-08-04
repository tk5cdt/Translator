import e from 'express';
import { connectDB } from '../configs/connectDB';

let getFavorite = async (req, res) => {
    try{
        let {uid} = req.query;
        let pool = await connectDB();
        let result = await pool.request().query(`SELECT WORDID, ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, UID FROM FAVORITE WHERE UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let saveFavorite = async (req, res) => {
    try{
        let{originalword, translatedword, fromlanguage, tolanguage, uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request()
            // .input('originalword', sql.NVarChar, originalword)
            // .input('translatedword', sql.NVarChar, translatedword)
            // .input('fromlanguage', sql.NVarChar, fromlanguage)
            // .input('tolanguage', sql.NVarChar, tolanguage)
            // .input('timesave', sql.DateTime, timesave)
            // .input('uid', sql.Int, uid)
            .query(`INSERT INTO FAVORITE(ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, UID) VALUES('${originalword}', '${translatedword}', '${fromlanguage}', '${tolanguage}', ${uid})`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let deleteFavorite = async (req, res) => {
    try{
        let {wordid, uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`DELETE FROM FAVORITE WHERE WORDID = ${wordid} AND UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

module.exports = {
    getFavorite,
    saveFavorite,
    deleteFavorite
}