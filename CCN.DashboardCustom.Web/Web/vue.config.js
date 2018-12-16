const path = require('path')
const merge = require('webpack-merge')
const webpack = require("webpack")
function resolve(dir) {
  console.log(dir);
  return path.join(__dirname, dir)
}
 
module.exports = {
  lintOnSave: false,
  configureWebpack: {
    resolve: {
      extensions: ['.js', '.vue', '.json'],
      alias: {
        '@': resolve('src'),
        '@p': resolve('src/plugins'),
        '@c': resolve('src/components'),
        'jquery': 'jquery',
        'vue$':'vue/dist/vue.js'
      }
    },
    plugins: [
      new webpack.ProvidePlugin({
        jQuery: "jquery",
        $: "jquery",
        "window.jQuery":"jquery"
      })
    ]
  },

  chainWebpack: config => {
    config.module
      .rule('images')
      .test(/\.(png|jpe?g|gif|webp)(\?.*)?$/)
      .use('url-loader')
      .loader('url-loader')
      .tap(options =>
        merge(options, {
          limit: 10,
        })
      )
  },

  baseUrl: process.env.NODE_ENV === 'production' ? '/page/common/' : '/',

}