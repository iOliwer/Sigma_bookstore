var BookStoreApp = angular.module('BookStoreApp', [
  'ngRoute',
  'BookControllers'
]);

BookStoreApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/', {
            templateUrl: 'partials/index.html',
            controller: 'indexCtrl'
        }).
        when('/books', {
            templateUrl: 'partials/book-list.html',
            controller: 'BookListCtrl'
        }).
        when('/books/:bookId', {
            templateUrl: 'partials/book-detail.html',
            controller: 'BookDetailCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });
  }]);