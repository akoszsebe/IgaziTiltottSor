'use strict';

let array = [];
let path = require('path');
let request = require("request");
module.exports = (app) => {

  app.get('/api/order', (req, res) => {

    console.log("vmmi");
    res.send(req.body.order)
  });

  app.post('/api/orders', (req, res) => {

    var order = req.body.order
    //var timer = Math.floor(Math.random() * Math.floor(10)) + 5;
    var timer = 3000;
    //if array.length == 0) {
    setTimeout(function () {

      request.post({
        headers: {
          'content-type': 'application/json'
        },
        uri: "http://localhost:5000/api/v1/ondrone/" + order.orderId,
        body: req.body.order,
        method: 'POST',
        json: true
      },
        function (error, response, body) {
          console.log(error, body);
          
        });

        setTimeout( function () {


          request.post({
            headers: {
              'content-type': 'application/json'
            },
            uri: "http://localhost:5000/api/v1/delivered/" + order.orderId,
            body: req.body.order,
            method: 'POST',
            json: true
          },
            function (error, response, body) {
              console.log(error, body);
              
            });
          
        }, timer);

    }, timer);
    console.log(order)
    res.send("order success")
  });

};

function logging() {
  console.log('Blah blah blah blah extra-blah');

}
