import * as express from "express";
import * as bodyParser from "body-parser";
import { Routes } from "./routes";
import { Strategy as JwtStrategy, ExtractJwt, VerifiedCallback } from "passport-jwt";
import { Strategy as LocalStrategy } from "passport-local";
import passport from "passport";
import jwt from "jsonwebtoken";
import bcrypt from "bcrypt";
import { DatabaseService } from "databaseService";

class App {

    app: express.Application;
    database = new DatabaseService();
    routes: Routes;

    constructor() {
        this.app = express.default();
        this.config();
        this.routes = new Routes(this.app, this.database);
    }

    private config(): void {
        // support application/json type post data
        this.app.use(bodyParser.json());
        //support application/x-www-form-urlencoded post data
        this.app.use(bodyParser.urlencoded({ extended: false }));
        this.configureJwtStrategy();
        this.database.initialize();
    }
    private configureJwtStrategy(): void {
        passport.use(new JwtStrategy({
            jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
            secretOrKey: 'secret',
            issuer: 'studbud',
            audience: 'studbudUsers',
        }, this.onJwtVerify));
        passport.use(new LocalStrategy(async (username, password, eb) => {
            var user = await this.database.findUser(username);
            if (!user) {
                eb("User does not exist.");
            } else {
                if (await bcrypt.compare(password, user.passwordHash)) {
                    eb(null, user);
                } else {
                    eb("Username or password incorrect.");
                }
            }
        }));
    }
    private onJwtVerify(payload: any, done: VerifiedCallback): void {
        done(null, payload);
    }
}

export default new App().app;