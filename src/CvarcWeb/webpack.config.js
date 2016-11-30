'use strict';

var webpack = require('webpack');
var path = require('path');
var autoprefixer = require('autoprefixer');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var WebpackNotifierPlugin = require('webpack-notifier');

var NODE_ENV = process.env.NODE_ENV || 'development';
var WATCH_MODE = process.env.WATCH_MODE;

module.exports = [{
    context: path.join(__dirname, 'wwwroot/entries'),
    entry: {
        index: "./pages/index"
    },

    externals: {
        'react': 'React',
        'react-dom': 'ReactDOM'
    },

    output: {
        path: path.join(__dirname, 'wwwroot/dist'),
        filename: 'js/[name].js'
    },

    watchOptions: {
        aggregateTimeout: 100
    },

    devtool: NODE_ENV === 'development' ? 'cheap-inline-module-source-map' : null,

    resolve: {
        extensions: ['', '.js', '.jsx', '.scss']
    },

    module: {
        loaders: [
            {
                test: /\.css$/,
                loader: ExtractTextPlugin.extract(NODE_ENV === 'development' ? 'css?sourceMap!postcss!resolve-url' : 'css!postcss!resolve-url'),
                include: [path.join(__dirname, 'wwwroot/css')]
            },
            {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract(NODE_ENV === 'development' ? 'css?sourceMap!postcss!resolve-url!sass?sourceMap' : 'css!postcss!resolve-url!sass?sourceMap'),
                include: [path.join(__dirname, 'wwwroot/css'), path.join(__dirname, 'wwwroot/entries/styles')]
            },
            {
                test: /\.jsx?/,
                loader: 'babel',
                query: {
                    presets: ['react', 'es2015']
                },
                include: [path.join(__dirname, 'wwwroot/entries/pages'), path.join(__dirname, 'wwwroot/js')]
            }
        ]
    },

    postcss: [autoprefixer({ browsers: ['> 0.5% in my stats', '> 1%'] })],

    plugins: [
        new webpack.NoErrorsPlugin(),

        // Собираем CSS/SCSS-бандлы в .css файлы, а в не в JS: https://webpack.github.io/docs/stylesheets.html#separate-css-bundle
        new ExtractTextPlugin('css/[name].css')
    ]
},
{
    context: path.join(__dirname, 'wwwroot/entries'),
    entry: {
        oldIE: ['babel-polyfill'],
        vendor: ['react', 'react-dom']
    },

    output: {
        path: path.join(__dirname, 'wwwroot/dist'),
        filename: 'js/[name].js'
    },

    devtool: null,

    resolve: {
        extensions: ['', '.js']
    },

    module: {
        loaders: [
            { test: require.resolve('react'), loader: 'expose?React' },
            { test: require.resolve('react-dom'), loader: 'expose?ReactDOM' }
        ]
    },

    plugins: [
        new webpack.NoErrorsPlugin(),

        // В режиме production отключается debug-вывод у React и, возможно, у каких-то других библиотек
        // Ловушка: React будет работать в IE8 только в режиме production, подробно написано в wat и в баге: https://github.com/facebook/react/issues/3188
        new webpack.DefinePlugin({
            'process.env.NODE_ENV': '"' + NODE_ENV + '"'
        })
    ]
}];

if (NODE_ENV === 'production') {
    module.exports.forEach((obj) => {
        obj.plugins.push(
            new webpack.optimize.UglifyJsPlugin({
                compress: {
                    // don't show unreachable variables etc
                    warnings: false,
                    drop_console: true,
                    unsafe: true
                },
                output: { comments: false },
                sourceMap: false
            })
        );
    });
}

if (WATCH_MODE === 'true') {
    module.exports.forEach((obj) => {
        obj.plugins.push(new WebpackNotifierPlugin());
    });
}