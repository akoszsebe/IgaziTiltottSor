'use strict';

let path = require('path')

// let PaymentInfo = {
//     raspberryid: String,
//     sensorid: String,
//     tempvalue: String,
//     tempdate: String
// };


const CardValidator = module.exports = function () {
  this.init()

};


CardValidator.prototype.init = function () {
  const self = this;
};


CardValidator.prototype.validateCard = function (cardnumber,cardexpiration,cvv,_callback) {
    return _callback(true);
};

