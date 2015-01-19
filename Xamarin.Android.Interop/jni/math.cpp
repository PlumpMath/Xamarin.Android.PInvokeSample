extern "C" int abs_int(int n)
{
  if (n < 0) return -n;
  return n;
}

extern "C" void abs_int_array(int* n, int size)
{
  //int size = (sizeof(n))/(sizeof(n[0]));
  for (int i = 0; i < size; i++) {
    n[i] = abs_int(n[i]);
  }
}

extern "C" double* range_from_doubles(double start, double end, double step, int& size)
{
  size = ((end - start) / step) + 1;
  double* result = new double[size];

  for (int i = 0; i < size; i++)
  {
    result[i] = (i * step) + start;
  }

  return result;
}

extern "C" int release_double_pointer(double* ptr)
{
  delete[] ptr;
  return 0;
}
