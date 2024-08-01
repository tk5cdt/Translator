import { connectDB } from "../configs/connectDB";
import bcrypt from "bcrypt";

const signup = async (req, res) => {
  try {
    let { username, email, password, confirmPassword } = req.body;
    const pool = await connectDB();
    const result = await pool.request().query(`Select * from ACCOUNT where email = '${email}'`);
    if (result.rowsAffected[0] > 0) {
      return res.status(400).json({ message: "Error" });
    }
    else{
        if(password !== confirmPassword){
            return res.status(400).json({ message: "Password is not match" });
        }   
        else
        {
            try {
                const salt = await bcrypt.genSalt(10);
                const hashedPassword = await bcrypt.hash(password, salt);
                const result = await pool.request().query(`Exec AddAccount '${username}', '${email}', '${hashedPassword}'`);
                return res.status(200).json({ message: "Success" });
            }
            catch (err) {
                console.log(err);
            }
        }
    }
  } catch (err) {
    console.log(err);
  }
}

const login = async (req, res) => {
    try {
        let { email, password } = req.body;
        const pool = await connectDB();
        const result = await pool.request().query(`'select * from ACCOUNT where email = '${email}'`);
        if (result.recordset.length === 0) {
            return res.status(400).json({ message: "Invalid email" });
        }
        const user = result.recordset[0];
        const match = await bcrypt.compare(password, user.pass);
        if (!match) {
            return res.status(400).json({ message: "Invalid password" });
        }
        else
        {
            req.session.user = user;
            return res.status(200).json({ message: "Success" });
        }
    } catch (err) {
        console.log(err);
    }
}


const logout = (req, res) => {
   req.session.destroy((error) => {
        if (error) {
            return res.status(500).json({ message: "Server error" });
        }
        res.clearCookie(process.env.SESSION_NAME);
        return res.json({ message: "Logout thanh cong" });
   })
}

module.exports = {
    signup,
    login,
    logout
}