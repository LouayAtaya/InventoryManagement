import {  NotEmptyValidatorDirective } from './not-empty.validator';

describe('NotEmptyDirective', () => {
  it('should create an instance', () => {
    const directive = new NotEmptyValidatorDirective();
    expect(directive).toBeTruthy();
  });
});
