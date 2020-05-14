SmartstoreApp.config(function ($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider, pageSize) {

    $locationProvider.html5Mode(false);
    $locationProvider.hashPrefix('!');
    $httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

    $stateProvider.state('list', {
        url: '/Category',
        templateUrl: '/Category/GetAllCategory',
        controller: 'categoryListController',
        resolve: {
            departmentList: function (requestSvc, $q) {

                var data = {
                    pageSize: pageSize
                };

                var deffered = $q.defer();
                requestSvc.post('/api/Category/GetAllCategory', data)

                    .then(function (data) {

                        if (data.errorStatus) {
                            return deffered.resolve([]);
                        }

                        return deffered.resolve(data.result);

                    }, function (error) {
                        alert('An error has occurred.');
                        deffered.resolve([]);
                    });

                return deffered.promise;
            }
        }
    })
        .state('add-new-category', {
            url: '/newcategory',
            templateUrl: '/Category/SetupCategory',
            controller: 'categoryController'
        })
        .state('edit-new-category', {
            url: '/EditCategory/:id',
            templateUrl: '/Category/EditCategory',
            controller: 'categoryController'
        });

    $urlRouterProvider.otherwise('/Category');
})
    .value('formClear', function (event) {
        typeof (event.currentTarget.form) === 'undefined' ? angular.element(event.currentTarget).get(0).reset() : angular.element(event.currentTarget.form)[0].reset();
    });