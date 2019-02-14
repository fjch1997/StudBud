import { Request, Response, Application } from "express";
import { UserInfoController } from "controllers/userInfo";
import { AuthenticationController } from "controllers/authentication";
import { DatabaseService } from "databaseService";

export class Routes {
    private userInfoController = new UserInfoController();
    private authenticationController: AuthenticationController;
    constructor(app: Application, database: DatabaseService) {
        this.authenticationController = new AuthenticationController(database);
        app.route('/userInfo')
            .get(this.userInfoController.getUserInfo);
        app.route("/login").post(this.authenticationController.login);
    }
}