const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(';')[0]
  : 'https://localhost:7242';

const PROXY_CONFIG = [
  {
    context: ['/settings', '/api/', '/silent-refresh.html', '/favicon.ico'],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive',
    },
  },
];

module.exports = PROXY_CONFIG;
