"use strict";

const ApiGateway = require("moleculer-web");

module.exports = {
	name: "api",
	mixins: [ApiGateway],

	// More info about settings: http://moleculer.services/docs/moleculer-web.html
	settings: {
		port: process.env.PORT || 8080,

		routes: [{
			path: "/api/v1/",
			whitelist: [
				// Access to any actions in all services
				"*"
			],
			aliases: {
				"REST storage": "storage"
			}
		}]

	}
};
