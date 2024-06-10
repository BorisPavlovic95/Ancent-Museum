const http = require('http');
const express = require('express');
const path = require('path');
const {setSocketInstance} = require('./socketio');

const app = express();
const port = process.env.PORT || "8000";

const server = http.Server(app);
setSocketInstance(server);

app.get("/", (req, res) =>{
    res.status(200).send("OK");
})

server.listen(port, () =>{
    console.log(`Slusamo samo na portu http://localhost:${port}`);
})