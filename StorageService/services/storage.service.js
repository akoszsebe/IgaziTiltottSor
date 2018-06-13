"use strict";

const DbService = require("moleculer-db");

module.exports = {
	name: "storage",
	mixins: [DbService],
	
	actions: {
    
    	/**
    	 * Say a 'Hello'
    	 *
    	 * @returns
    	 */
    	hello() {
    		return "Hello From STORAGE";
    	}
	}
};