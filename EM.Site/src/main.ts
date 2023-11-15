/// <reference types="@angular/localize" />

import {enableProdMode} from '@angular/core';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import {AppModule} from './app/app.module';
import {environment} from './environments/environment';

export function getBaseUrl() {
  console.log('BASE_URL', document.getElementsByTagName('base')[0].href);
  return document.getElementsByTagName('base')[0].href;
}

export function getApiUrl() {
  return ' http://localhost:5140';
}

export function getPositions() {

  return [
    {key: 0, value: "N/A"},
    {key: 1, value: "Coder"},
    {key: 2, value: "Programmer"},
    {key: 3, value: "Full-Stack Developer"},
    {key: 4, value: "Server Developer"},
    {key: 5, value: "UI Developer"},
    {key: 6, value: "Designer"},
    {key: 7, value: "Architect"}
  ];
}

const providers = [
  {provide: 'BASE_URL', useFactory: getBaseUrl, deps: []},
  {provide: 'API_URL', useFactory: getApiUrl, deps: []},
  {provide: 'POSITIONS', useFactory: getPositions, deps: []},
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
