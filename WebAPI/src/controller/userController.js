import { connectDB } from "../configs/connectDB";
import bcrypt from "bcrypt";

const signup = async (req, res) => {
  try {
    let { username, email, password, confirmPassword } = req.body;
    console.log(password);
    const pool = await connectDB();
    const result = await pool.request().query(`Select * from ACCOUNT where email = '${email}'`);
    if (result.rowsAffected[0] > 0) {
      return res.status(400).json({ message: "Email already exists" });
    }
    else{
        if(password !== confirmPassword){
            return res.status(400).json({ message: "Password is not match" });
        }   
        else
        {
            try {
                const salt = await bcrypt.genSaltSync(10);
                const hashedPassword = await bcrypt.hashSync(password, salt);
                console.log(hashedPassword);
                const isMatch = await bcrypt.compare(password, hashedPassword);
                console.log(isMatch);
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
    let { email, password } = req.body;
    const pool = await connectDB();
    console.log(password);
    // console.log(username);
    const result = await pool.request().query(`select * from ACCOUNT where email = '${email}'`)
    if (result.recordset.length === 0) {
        return res.status(400).json({ message: "Email is invalid" });
        // return res.render("login.ejs", { message: "email không tồn tại" });
    }
    else {
        const user = result.recordset[0];
        const isMatch = await bcrypt.compare(password, user.PASS);
        console.log(user.PASS);
        console.log(isMatch);
        if (isMatch) {
            req.session.user = user;

            return res.status(200).json(user);

        }
        else {
            return res.status(400).json({ message: "Password is incorrect" });
        }
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