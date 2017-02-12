import { AngelisimmaPage } from './app.po';

describe('angelisimma App', function() {
  let page: AngelisimmaPage;

  beforeEach(() => {
    page = new AngelisimmaPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
