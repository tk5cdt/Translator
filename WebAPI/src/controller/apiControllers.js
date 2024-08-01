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

let newAccount = async (req, res) => {
    let { username, email, password} = req.body;
    console.log(req.body);
    const pool = await connectDB();
    // const result = await pool.request().query(`Exec AddAccount '${username}', '${email}', '${password}'`);
    const result = await pool.request().query(`insert into ACCOUNT(username, email, pass) values ('${username}', '${email}', '${password}')`)

    return res.status(200).json(result.recordset);
}

module.exports = {
    getAccount: getAccount,
    newAccount: newAccount
}