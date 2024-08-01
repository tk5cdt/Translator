import express, { request } from "express";
import apiController from "../controller/apiControllers";
import userController from "../controller/userController";

const router = express.Router();

const initApiRoute = (app) => {
    router.get('/getaccount', apiController.getAccount);
    // router.post('/newaccount', userController.signup);
    router.post('/newaccount', apiController.newAccount);
    router.post('/hi', (req, res) => {
        res.send(req.body)
    });
    router.post('/login', userController.login);
    return app.use('/api', router);
}



module.exports = initApiRoute;