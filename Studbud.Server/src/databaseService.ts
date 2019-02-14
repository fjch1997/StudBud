import mysql from "mysql";
import bcrypt from "bcrypt";

export interface User {
    username: string;
    passwordHash: string;
}

export class DatabaseService {
    connection: mysql.Connection;
    constructor() {
        this.connection = mysql.createConnection(process.env["MYSQLCONNSTR_localdb"] as string);
    }
    initialize() {
        this.connection.connect();
        this.connection.query("ALTER TABLE Users ADD COLUMN username varchar(32) AUTO_INCREMENT PRIMARY KEY, ADD COLUMN passwordHash BINARY(60)")
    }
    async createUser(username: string, password: string): Promise<void> {
        var hash = await bcrypt.hash(password, 10)
        await new Promise((resolve, reject) => {
            this.connection.query("INSERT INTO Users (username, passwordHash) VALUES ('" + username + "', '" + hash + "')", (err, result) => {
                if (err) {
                    reject(err)
                }
                else {
                    resolve();
                }
            })
        });
    }
    findUser(username: string): Promise<User | null> {
        return new Promise<User | null>((resolve, reject) =>
            this.connection.query("SELECT * FROM customers", (err, result) => {
                if (err) {
                    reject(err);
                } else {
                    if (result.length == 0) {
                        resolve(null);
                    } else {
                        resolve({ username: result.username, passwordHash: result.passwordHash })
                    }
                }
            }));
    }
}
