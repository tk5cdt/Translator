import express from "express";
import apiController from "../controller/apiControllers";

const router = express.Router();

const initApiRoute = (app) => {
    router.get('/getaccount', apiController.getAccount);
    return app.use('/api', router);
}

module.exports = initApiRoute;