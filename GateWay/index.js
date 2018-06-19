'use strict';

let express = require('express'),
  app = express(),
  bodyParser = require('body-parser'),
  http = require('http').Server(app),
  request = require("request");


// set port
app.set('port', process.env.PORT || 8080);

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));

app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', 'http://localhost:8080');
  res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
  res.header('Access-Control-Allow-Headers', 'Content-Type');
  res.header('Access-Control-Allow-Credentials', 'true');
  next()
});

app.use(function (req, res, next) {
  console.log('Time:', Date.now())
  request("https://graph.facebook.com/me?access_token="+req.query.access_token, function(error, response, body) {
          body = JSON.parse(body);
          console.log(req.query.access_token,body.error);
          if (body.error){
            res.status(400);
            res.send('unauthenticated');
            return;
          }	
          next()
  })
})


// run
http.listen(app.get('port'), () => {
  console.info('App is running on port ', app.get('port'))
});

exports = module.exports = app;

// routing
require('./backend/routes')(app);

function fill() {

  var beer1 = {
      "beername": "Igazi",
      "price": 3,
      "quantity": 10,
      "_id" : 1
  };

  var beer2 = {
      "beername": "Tiltott",
      "price": 3,
      "quantity": 10,
      "_id" : 2
  };

  var beer3 = {
      "beername": "Jegafonya",
      "price": 4,
      "quantity": 56,
      "_id" : 3  
  };

  var beer4 = {
      "beername": "Szekely",
      "price": 4,
      "quantity": 5,
      "_id" : 4  
  }

  var beer5 = {
      "beername": "Barna",
      "price": 6,
      "quantity": 100,
      "_id" : 5  
  };

  callStorage(beer1)
  callStorage(beer2)
  callStorage(beer3)
  callStorage(beer4)
  callStorage(beer5)

}


function callStorage(beer) {
  request.post({
      headers: {
          'content-type': 'application/json'
      },
      uri: "http://storage-service:8080/api/v1/storage",
      body: beer,
      method: 'POST',
      json: true
  },
      function (error, response, body) {
          console.log(error, body);

      });
}

fill()