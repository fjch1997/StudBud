import { Request, Response, Application } from "express";
import { UserInfoController } from "controllers/userInfo";

export class Routes {
    private userInfoController = new UserInfoController();
    public initialize(app: Application): void {
        app.route('/userInfo')
            .get(this.userInfoController.getUserInfo);
    }
}