(function () {
    'use strict';

    angular
        .module('signin')
        .controller('RegisterController', RegisterController);
    
    RegisterController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];

    function RegisterController(UserService, $location, $rootScope, FlashService) {
        var vm = this;

        vm.register = register;
        //vm.datePickerInti = datePickerInti;
        datePickerInti();

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

        function datePickerInti() {
            $("#datepicker").datepicker({
                beforeShow: function (input, inst) {
                    setTimeout(function () {
                        var rect = input.getBoundingClientRect();
                        var topP = rect.top;
                        var leftP = rect.right;
                        inst.dpDiv.css({
                            top: topP,
                            left: leftP
                        });
                    }, 0);
                }
            });
        }
    }

})();
