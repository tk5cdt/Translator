import e from 'express';
import { connectDB } from '../configs/connectDB';
import axios from "axios";

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

let translateText = async (req, res) => {
    const { q, source, target, format, alternatives } = req.body;
    try {
        const response = await axios.post('http://localhost:5000/translate', {
            q: q,
            source: source || 'auto',
            target: target || 'en',
            format: format || 'text',
            alternatives: alternatives || 2
        }, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
        res.status(200).json(response.data);
    } catch (err) {
        console.log(err);
        res.status(500).send('Internal Server Error');
    }
}

module.exports = {
    getAccount: getAccount,
    newAccount: newAccount,
    translateText: translateText
}