const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/ventas", "/api",

];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7267',
        secure: false
    });

    app.use(appProxy);
};
