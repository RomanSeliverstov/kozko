<?php

/*
|--------------------------------------------------------------------------
| Routes File
|--------------------------------------------------------------------------
|
| Here is where you will register all of the routes in an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the controller to call when that URI is requested.
|


Route::get('/', function () {
    return view('welcome');
});
*/
/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| This route group applies the "web" middleware group to every route
| it contains. The "web" middleware group is defined in your HTTP
| kernel and includes session state, CSRF protection, and more.
|
*/

Route::get('/', [ 'as'    => 'home', 'uses'  => 'HomeController@index'
]);

Route::get('/city', [ 'as'    => 'city', 'uses'  => 'HomeController@city'
]);

Route::get('/weekday', [ 'as'    => 'weekday', 'uses'  => 'HomeController@weekday'
]);

Route::get('/friends', [ 'as'    => 'friends', 'uses'  => 'HomeController@friends'
]);

Route::get('/addfriend', [ 'as'    => 'addfriend', 'uses'  => 'HomeController@addfriend'
]);


Route::group(['middleware' => ['web']], function () {
    //
});
