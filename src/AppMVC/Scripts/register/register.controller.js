(function () {
    'use strict';

    angular
        .module('signin')
        .controller('RegisterController', RegisterController);

    angular
        .module('signin')
        .directive('calendar', function () {
            return {
                require: 'ngModel',
                link: function (scope, el, attr, ngModel) {
                    $(el).datepicker({
                        dateFormat: 'yy-mm-dd',
                        onSelect: function (dateText) {
                            scope.$apply(function () {
                                ngModel.$setViewValue(dateText);
                            });
                        }
                    });
                }
            };
        });


    RegisterController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
    function RegisterController(UserService, $location, $rootScope, FlashService) {
        var vm = this;

        vm.register = register;
        
        function register() {
            vm.dataLoading = true;
            UserService.Create(vm.user)
                .then(function (response) {
                    if (response.success) {
                        FlashService.Success('Registration successful', true);
                        debugger;
                        $location.path('/login');
                    } else {
                        FlashService.Error(response.message);
                        vm.dataLoading = false;
                    }
                });
        }
    }



    //function datePicker() {
    //    vm.user.dob = new Date();

    //    vm.minDate = new Date(
    //        vm.user.dob.getFullYear(),
    //        vm.user.dob.getMonth() - 2,
    //        vm.user.dob.getDate()
    //    );

    //    vm.maxDate = new Date(
    //        vm.user.dob.getFullYear(),
    //        vm.user.dob.getMonth() + 2,
    //        vm.user.dob.getDate()
    //    );
    //}

})();
