import { MicroservicesTemplatePage } from './app.po';

describe('Microservices App', function() {
  let page: MicroservicesTemplatePage;

  beforeEach(() => {
    page = new MicroservicesTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
