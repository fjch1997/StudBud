import { Request, Response } from 'express';
import passport from 'passport';
import jwt from 'jsonwebtoken';
import { DatabaseService } from 'databaseService';
export class AuthenticationController {
    database: DatabaseService;
    constructor(database: DatabaseService) {
        this.database = database;
    }
    public login(req: Request, res: Response) {
        passport.authenticate('local', { session: false }, (err, user, info) => {
            if (err || !user) {
                return res.status(400).json({
                    message: 'Something is not right',
                    user: user
                });
            }
            req.login(user, { session: false }, (err) => {
                if (err) {
                    res.send(err);
                }
                // generate a signed son web token with the contents of user object and return it in the response
                const token = jwt.sign(user, 'your_jwt_secret');
                return res.json({ user, token });
            });
        })(req, res);
    }
    public register(req: Request, res: Response) {
        var username = req.body.username
        var user = this.database.findUser(username);
        if (user == null) {
            this.database.createUser(username, req.body.password);
            res.status(200);
        } else {
            res.status(409);
        }
    }
}