(function () {
    QUnit.config.testTimeout = 10000;

    var stringformat = QUnit.stringformat;

    module('Web API GET Endpoint Tests');

    var apiUrls = [

        //List all APIs Here

        '/api/Teas/',
        '/api/Sups/'
    ];


    var apiUrlslen = apiUrls.length;

    // Test only that the Web API responded to the request with 'success'
    var endpointTest = function (url) {
        $.ajax({
            url: url,
            dataType: 'json',
            success: function (result) {
                ok(true, 'GET succeeded for ' + url);
                ok(!!result, 'Successfully Fetched the Data');
                start();
            },
            error: function (result) {
                ok(false,
                    stringformat('GET on \'{0}\' failed with status=\'{1}\': {2}',
                        url, result.status, result.responseText));
                start();
            }
        });
    };

    // Returns an endpointTest function for a given URL
    var endpointTests = function (url) {
        return function () { endpointTest(url); };
    };

    // Test each endpoint in apiUrls
    for (var i = 0; i < apiUrlslen; i++) {
        var apiUrl = apiUrls[i];
        asyncTest(
            'API can be reached: ' + apiUrl,
            endpointTests(apiUrl));
    };
})(); (function () {
    QUnit.config.testTimeout = 10000;

    var stringformat = QUnit.stringformat;

    module('Web API GET Endpoint Tests');

    var apiUrls = [

        //List all APIs Here

        '/api/Teas/',
        '/api/Sups/',
        '/api/Carts/',
        '/api/Details/',
        '/api/Home/',
        '/api/Store/',
        '/api/Types/',
        '/api/TypeMenu/ '
    ];


    var apiUrlslen = apiUrls.length;

    // Test only that the Web API responded to the request with 'success'
    var endpointTest = function (url) {
        $.ajax({
            url: url,
            dataType: 'json',
            success: function (result) {
                ok(true, 'GET succeeded for ' + url);
                ok(!!result, 'Successfully Fetched the Data');
                start();
            },
            error: function (result) {
                ok(false,
                    string.format('GET on \'{0}\' failed with status=\'{1}\': {2}',
                        url, result.status, result.responseText));
                start();
            }
        });
    };

    // Returns an endpointTest function for a given URL
    var endpointTests = function (url) {
        return function () { endpointTest(url); };
    };

    // Test each endpoint in apiUrls
    for (var i = 0; i < apiUrlslen; i++) {
        var apiUrl = apiUrls[i];
        asyncTest(
            'API can be reached: ' + apiUrl,
            endpointTests(apiUrl));
    };
})(); (function () {
    QUnit.config.testTimeout = 10000;

    var stringformat = QUnit.stringformat;

    module('Web API GET Endpoint Tests');

    var apiUrls = [

        //List all APIs Here

        '/api/Teas/',
        '/api/Sups/',
        '/api/Carts/',
        '/api/Details/ ',
        '/api/Home/',
        '/api/Store/',
        '/api/Types/',
        '/api/TypeMenu/'

    ];


    var apiUrlslen = apiUrls.length;

    // Test only that the Web API responded to the request with 'success'
    var endpointTest = function (url) {
        $.ajax({
            url: url,
            dataType: 'json',
            success: function (result) {
                ok(true, 'GET succeeded for ' + url);
                ok(!!result, 'Successfully Fetched the Data');
                start();
            },
            error: function (result) {
                ok(false,
                    stringformat('GET on \'{0}\' failed with status=\'{1}\': {2}',
                        url, result.status, result.responseText));
                start();
            }
        });
    };

    // Returns an endpointTest function for a given URL
    var endpointTests = function (url) {
        return function () { endpointTest(url); };
    };

    // Test each endpoint in apiUrls
    for (var i = 0; i < apiUrlslen; i++) {
        var apiUrl = apiUrls[i];
        asyncTest(
            'API can be reached: ' + apiUrl,
            endpointTests(apiUrl));
    };
})();