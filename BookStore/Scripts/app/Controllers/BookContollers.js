var BookControllers = angular.module('BookControllers', []);


BookControllers.controller('indexCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $scope.filter = function () {
          if ($scope.searchterm.length > 0) {
              $scope.isSearchterm = true;
          } else {
              $scope.isSearchterm = false;
          }
          $http.get('api/books/' + $scope.searchterm).success(function (data) {
              $scope.books = data;
          });
      };
  }]);

BookControllers.controller('BookListCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('api/books').success(function (data) {
          $scope.books = data;
      });
  }]);

BookControllers.controller('BookDetailCtrl', ['$scope', '$routeParams', '$http',
  function ($scope, $routeParams, $http) {
      $http.get('api/books/' + $routeParams.bookId).success(function (data) {
          $scope.book = data;
      });
  }]);