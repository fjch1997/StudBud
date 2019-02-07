import { Request, Response } from 'express';
export class UserInfo {
    username: string;
    profilePictureUri: string;
    constructor(username: string, profilePictureUri: string) {
        this.username = username;
        this.profilePictureUri = profilePictureUri;
    }
}
export class UserInfoController {
    public getUserInfo(req: Request, res: Response) {
        res.json(new UserInfo("", ""));
    }
}