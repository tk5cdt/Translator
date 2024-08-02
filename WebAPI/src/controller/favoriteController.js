import { connectDB } from '../configs/connectDB';

let getFavorite = async (req, res) => {
    try{
        let {uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`SELECT ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE FROM FAVORITE WHERE UID = ${uid}`);
        res.status(200).json(result.recordset);
    }catch (err) {
        console.log(err);
    }
}

let saveFavorite = async (req, res) => {
    try{
        let{originalword, translatedword, fromlanguage, tolanguage,timesave, uid} = req.body;
        let pool = await connectDB();
        let result = await pool.request().query(`INSERT INTO FAVORITE(ORIGINALWORD, TRANSLATEDWORD, FROMLANGUAGE, TOLANGUAGE, TIMESAVE, UID) VALUES('${originalword}', '${translatedword}', '${fromlanguage}', '${tolanguage}', '${timesave}', ${uid})`);
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