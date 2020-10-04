new webpack.DefinePlugin({
    'process.env': {
      'API_URL': JSON.stringify('http://localhost:5000/graphql')
    }
  })