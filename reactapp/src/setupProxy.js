const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/pushpins",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7094',
        secure: false
    });

    app.use(appProxy);
};
