"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
// lib/server.ts
const app_1 = __importDefault(require("./app"));
const PORT = 3000;
app_1.default.listen(PORT, () => {
    console.log('Express server listening on port ' + PORT);
});
