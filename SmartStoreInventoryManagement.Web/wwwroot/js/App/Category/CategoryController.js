
(function () {
    SmartstoreApp.controller('categoryListController', ['$scope', 'requestSvc', 'categoryList', 'pageSize', function (vm, requestSvc, categoryList, pageSize) {
        vm.categoryList = categoryList || [];
        vm.pageIndex = 1;
        vm.pageSize = pageSize;
        vm.currentUser = {};
        var cachedUrl;



        vm.$watch('categoryList', function () {
            vm.total = categoryList.length > 0 ? categoryList[0].TotalCount : 0;
        }, true);

        vm.search = function (event, url) {
            event.preventDefault(false);
            cachedUrl = url;

            var data = $(event.target).serialize2JSON();
            initPagination(cachedUrl, data);
        };


        function initPagination(url, data) {
            requestSvc.post(url, data)
                .then(function (data) {

                    if (data.errorStatus) {
                        alert(data.errorMessage);
                        return;
                    }

                    vm.categoryList = data.result;
                    vm.total = data.result.length > 0 ? data.result[0].TotalCount : 0;

                }, function (error) {
                    alert('An error has occurred.');
                });
        }


        function pageChange(url) {
            var data = { pageSize: pageSize, pageIndex: vm.pageIndex };
            initPagination(url, data);
        }

        vm.pageChange = pageChange;

        vm.init = function (id) {

            if (!id)
                return;

            $(id).validate({

                rules: {
                    name: {
                        required: true,
                    },
                    description: {
                        required: true
                    },

                }, messages: {

                    name: 'Client name cannot be empty',
                    description: {
                        required: 'Email is required',
                        number: 'Value entered, please supply a value greater than zero'
                    }
                }
            });
        }


        vm.SetDesignationStatus = function (url, id) {

            if (!confirm("Are you sure you want to alter this designation"))
                return;

            requestSvc.post(url + id).then(function (data) {
                vm.designationList.forEach(function (item, index) {
                    if (item.Id === id) {
                        item.Status = item.Status === 'Active' ? 'In-active' : 'Active';
                    }
                })
            })
        }

        //Deleting code here       
        vm.deleteCategory = function (url, id) {

            if (!confirm("Are you sure you want to alter this department"))
                return;

            requestSvc.post(url, [id])
                .then(function (data) {
                    vm.categoryList.forEach(function (item, index) {
                        if (item.id === id) {
                            vm.categoryList.splice(index, 1);
                        }
                    })
                    alert(data.message);
                }, function () {
                    alert('Error in Deleting Record');
                });
        }

    }]);

    SmartstoreApp.controller('categoryController', ['$scope', 'requestSvc', '$stateParams', function (vm, requestSvc, stateParams) {
        vm.$on('$viewContentLoaded', function () {
            $('.datepicker').datepicker({
                format: 'yyyy-mm-dd'
            });
        });

        vm.cat = {};
        vm.saveCategory = function (e, url) {

            //if (!alert('Are you sure you want to continue/.'))
            //    return;

            e.preventDefault(false);

            if (!$(e.target).valid()) {
                alert('Invalid submission');
                return;
            }

            var formData = $('#category').serialize2JSON();

            requestSvc.post(url, formData).then(function (data) {

                if (!data.errorStatus) {

                    alert(data.message || 'Saved successfully');
                    $(e.target).get(0).reset();
                    return;
                } else {
                    alert(data.errorMessage);
                }

            }, function (error, status) {
                alert('Soory an error occured, Please try again');
            });
        }


        vm.getEditablecategory = function (url) {

            requestSvc.get(url + stateParams.id).then(function (data) {
                vm.cat = data.result;
            }, function () {
                alert('an error occured');
            })
        }


        vm.updateCategory = function (e, url) {

            requestSvc.post(url, vm.cat)
                .then(function (data) {

                    if (data.errorStatus) {
                        alert('An error occured, Please try again.')
                    }
                    else {
                        alert(data.message || 'Update successfully');
                    }
                }, function () {

                    alert('Error in updating record');

                });
        }



    }]);
})();