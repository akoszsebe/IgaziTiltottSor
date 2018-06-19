var httpProxy = require('http-proxy');
var targetHost = '192.168.99.100';
var port = 31776;
httpProxy.createProxyServer({target:'http://' + targetHost + ':' + port}).listen(8080);