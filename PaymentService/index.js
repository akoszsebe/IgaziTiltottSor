'use strict';

let express = require('express'),
  app = express(),
  bodyParser = require('body-parser'),
  http = require('http').Server(app)


// set port
app.set('port', process.env.PORT || 8080);

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));


// run
http.listen(app.get('port'), () => {
  console.info('App is running on port ', app.get('port'))
});

exports = module.exports = app;

// routing
require('./backend/routes')(app);
