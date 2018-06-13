'use strict';

let path = require('path');
let request = require("request");
module.exports = (app) => {

  app.get('/api/orders', (req, res) => {
    request("http://localhost:4200/api/v1/orders", function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

  app.get('/api/orders/byuser', (req, res) => {
    console.log(req.headers.useremail)
    request( { headers: { 'useremail' : req.headers.useremail} ,
               uri: "http://localhost:4200/api/v1/orders/byuser",
               method: 'GET'  }, 
    function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

  app.post('/api/orders', (req, res) => {
    console.log(req.body)
    request.post( { 
            headers : {
              'content-type': 'application/json'
            },
              uri : "http://localhost:4200/api/v1/orders",
              body : req.body,           
              method: 'POST',
              json: true }, 
    function(error, response, body) {
      console.log(error,body);
      res.send(body)
    });
  });

};
