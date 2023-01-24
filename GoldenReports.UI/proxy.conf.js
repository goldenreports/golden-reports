const winston = require('winston');

function logProvider() {
  return winston.createLogger({
    level: 'debug',
    format: winston.format.combine(
      winston.format.splat(),
      winston.format.simple()
    ),
    transports: [new winston.transports.Console()],
  });
}

const PROXY_CONFIG = [
  {
    context: [
      "/api",
   ],
    target: 'https://localhost:7217',
    changeOrigin: true,
    secure: false,
    logLevel: 'debug',
    logProvider,
    pathRewrite: {
      "^/api": ""
    }
  }
]

module.exports = PROXY_CONFIG;
