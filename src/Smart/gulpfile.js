/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

var gulp = require('gulp'),
    sass = require('gulp-sass'),
    rimraf = require('rimraf');

gulp.task("sass", function () {
    return gulp.src('./Styles/**/*.scss')
    .pipe(sass())
    .pipe(gulp.dest(paths.webroot + '/css'));
});

var paths = {
    webroot: "./wwwroot/"
};


