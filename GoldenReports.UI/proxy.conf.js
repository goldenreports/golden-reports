const PROXY_CONFIG = [
  {
    context: [
      "/api",
   ],
    target: 'https://localhost:7217',
    secure: false
  }
]

module.exports = PROXY_CONFIG;
