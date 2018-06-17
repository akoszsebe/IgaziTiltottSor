'use strict';

let path = require('path');
let request = require("request");
module.exports = (app) => {

  app.get('/api/orders', (req, res) => {
    request("http://localhost:5000/api/v1/orders", function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

  app.get('/api/orders/byuser', (req, res) => {
    console.log(req.headers.useremail)
    request( { headers: { 'useremail' : req.headers.useremail} ,
               uri: "http://localhost:5000/api/v1/orders/byuser",
               method: 'GET'  }, 
    function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

  app.post('/api/orders', (req, res) => {
    console.log(req.body.card)
    request.post( { 
            headers : {
              'content-type': 'application/json'
            },
              uri : "http://localhost:5000/api/v1/orders",
              body : req.body.order,           
              method: 'POST',
              json: true }, 
    function(error, response, body) {
      console.log(error,body);
      if (body == true){
        request.post( { 
          headers : {
            'content-type': 'application/json'
          },
            uri : "http://localhost:3000/api/payorder",
            body : req.body.card,           
            method: 'POST',
            json: true }, 
            function(error, response, body) {
              console.log(error,body);
              res.send(true)
            });
        }
      });
  });

  app.get('/api/users/one', (req, res) => {
    console.log(req.headers.useremail)
    request( { headers: { 'useremail' : req.headers.useremail} ,
               uri: "http://localhost:61241/api/users/one",
               method: 'GET'  }, 
    function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

  app.get('/api/storage', (req, res) => {
    request("http://storage-service:8080/api/v1/storage", function(error, response, body) {
      console.log(body);
      res.send(body)
    })
  });

};
