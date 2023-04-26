"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/taskHub")
    .build();

connection.on("NewTaskRecived", function (message) {
    alert(message);

});
     
connection.start().catch(function (err) {
    return console.error(err.toString());
});


