var express = require('express');

var app = express();

var server = app.listen(process.env.PORT || 3000, listen);


function listen() {
  var host = server.address().address;
  var port = server.address().port;
  console.log('Example app listening at http://' + host + ':' + port);
}

app.use(express.static('public'));



var io = require('socket.io')(server);


io.sockets.on('connection', function (socket) {
    
    console.log("new connection: " + socket.id);
    socket.on("UnityHello", () => {
        console.log("Hello from unity");
    });

    socket.on("PointTransform", (data) => {
        console.log("Point Location: " + "X: " + data.TransformX + " Y: " + data.TransformY + " X: " + data.TransformZ);
        let pointData = data;
        socket.broadcast.emit("PointFromUnity", pointData);
    });
});

var localtunnel = require('localtunnel');
let PORT = "3000";

let TunnelOpt = { subdomain: "roxyrypler"};

var tunnel = localtunnel(PORT, TunnelOpt, function(err, tunnel) {
    if (err) {
        console.log(err);
    }
    console.log(tunnel.url);
});

tunnel.on('close', function() {
    console.log("Tunnel closed");
});