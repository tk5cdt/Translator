import express, { request } from "express";
import apiController from "../controller/apiControllers";
import userController from "../controller/userController";
import historyController from "../controller/historyController";
import favoriteController from "../controller/favoriteController";

const router = express.Router();

const initApiRoute = (app) => {
    router.get('/getaccount', apiController.getAccount);
    router.post('/translate', apiController.translateText);
    router.post('/newaccount', userController.signup);
    //router.post('/newaccount', apiController.newAccount);
    router.post('/login', userController.login);
    router.post('/logout', userController.logout)

    router.get('/gethistory', historyController.getHistory);
    router.post('/savehistory', historyController.saveHistory);
    router.post('/deletehistory', historyController.deleteHistory);
    router.post('/deleteallhistory', historyController.deleteAllHistory);
    router.post('/updatehistory', historyController.updateHistory);

    router.get('/getfavorite', favoriteController.getFavorite);
    router.post('/savefavorite', favoriteController.saveFavorite);
    router.post('/deletefavorite', favoriteController.deleteFavorite);
    router.post('/deletefavoritehistory', favoriteController.deleteFavoriteHistory);

    return app.use('/api', router);
}



module.exports = initApiRoute;