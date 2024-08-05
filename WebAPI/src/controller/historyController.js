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
        let {originalword, translatedword, fromlanguage, tolanguage,timesave, uid} = req.body;

        let pool = await connectDB();
        let result = await pool.request()
            .input('originalword', sql.NVarChar, originalword)
            .input('translatedword', sql.NVarChar, translatedword)
            .input('fromlanguage', sql.NVarChar, fromlanguage)
            .input('tolanguage', sql.NVarChar, tolanguage)
            .input('timesave', sql.DateTime, timesave)
            .input('isfavorite', sql.Bit, isfavorite)
            .input('uid', sql.Int, uid)
            .query('INSERT INTO HISTORY(ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE, UID, ISFAVORITE) VALUES(@originalword, @translatedword, @fromlanguage, @tolanguage, @timesave, @uid, @isfavorite)');
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