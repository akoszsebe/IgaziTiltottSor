'use strict';

let path = require('path');
let request = require("request");
module.exports = (app) => {

  app.post('/api/payorder', (req, res) => {
    console.log(req.body)
      res.send(true)
  });

};
