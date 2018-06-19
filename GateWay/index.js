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
