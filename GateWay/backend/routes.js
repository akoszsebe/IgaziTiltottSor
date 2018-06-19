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
    req.body.order.orderid = Math.floor(Math.random() * (5000 - 2000) + 2000);
    var order = req.body.order;
    console.log(order)
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
              request.post( { 
                headers : {
                  'content-type': 'application/json'
                },
                  uri : "http://localhost:8082/api/orders",
                  body : order,           
                  method: 'POST',
                  json: true }, 
                  function(error, response, body) {
                    console.log(error,body);
                    res.send(true);
                  });
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
    request("http://localhost:8081/api/v1/storage", function(error, response, body) {
      body = JSON.parse(body);
      console.log(body.rows);
      res.send(body.rows)
    })
  });

  app.post('/api/users', (req, res) => {
    console.log(req.body)
    request.post( { 
            headers : {
              'content-type': 'application/json'
            },
              uri : "http://localhost:61241/api/users",
              body : req.body,           
              method: 'POST',
              json: true }, 
    function(error, response, body) {
      console.log(error,body);
      res.send(true);
    })
  });
};
