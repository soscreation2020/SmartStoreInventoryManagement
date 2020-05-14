//<reference path="../SmartstoreApp.js" />
(function () {

    SmartstoreApp.service('requestSvc', ['$http', '$q', requestSvc]);

    function requestSvc(http, q) {
        var svc = this;

        svc.get = function (requestUrl) {
            var resolver = q.defer();
            http({
                method: 'GET',
                url: requestUrl
            })
                .then(function (response, statusCode) {
                    resolver.resolve(response.data);
                }, function (error) {
                    resolver.reject(error);
                });
            return resolver.promise;
        };

        svc.post = function (requestUrl, data) {
            var resolver = q.defer();
            http({
                method: 'POST',
                url: requestUrl,
                data: data
            }).then(function (responseResult, statusCode) {
                resolver.resolve(responseResult.data);
            }, function (error) {
                resolver.reject(error)
            });
            return resolver.promise;
        }
    }
})();