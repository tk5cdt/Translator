import e from 'express';
import { connectDB } from '../configs/connectDB';

let getAccount = async (req, res) =>{
    try {
        let pool = await connectDB();
        let result = await pool.request().query('select * from ACCOUNT');
        res.status(200).json(result.recordset);
    } catch (err) {
        console.log(err);
    }
}

module.exports = {
    getAccount
}